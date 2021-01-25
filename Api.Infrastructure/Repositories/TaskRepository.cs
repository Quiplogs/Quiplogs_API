using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Data.SqlClient;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Helpers;
using Quiplogs.Infrastructure.SqlContext;
using Quiplogs.Inventory.Data.Entities;
using Quiplogs.Inventory.Dto.Repositories.Task;
using Quiplogs.Inventory.Interfces.Repositories;

namespace Quiplogs.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly IMapper _mapper;
        private readonly SqlDbContext _context;
        private ICaching _cache;

        public TaskRepository(IMapper mapper, SqlDbContext context, ICaching cache)
        {
            _mapper = mapper;
            _context = context;
            _cache = cache;
        }

        public async Task<ListTaskResponse> List(Guid companyId, int pageNumber, string filterName, int pageSize)
        {
            try
            {
                var TaskList = _context.Tasks.Where(x =>
                     x.CompanyId == companyId
                    && (filterName == null || x.Name.Contains(filterName)))
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize).ToList();

                var mappedTasks = _mapper.Map<List<Quiplogs.Inventory.Domain.Entities.TaskEntity>>(TaskList);
                return new ListTaskResponse(mappedTasks, true, null);
            }
            catch (SqlException ex)
            {
                return new ListTaskResponse(null, false, new[] { new Error("", $"Error fetching Task. {ex.Message}") });
            }
        }

        public async Task<GetTaskResponse> Get(Guid id)
        {
            try
            {
                var Task = _context.Tasks.FirstOrDefault(x => x.Id == id);

                var mappedTask = _mapper.Map<Quiplogs.Inventory.Domain.Entities.TaskEntity>(Task);
                return new GetTaskResponse(mappedTask, true, null);
            }
            catch (SqlException ex)
            {
                return new GetTaskResponse(null, false, new[] { new Error("", $"Error fetching Task. {ex.Message}") });
            }
        }

        public async Task<PutTaskResponse> Put(Quiplogs.Inventory.Domain.Entities.TaskEntity Task)
        {
            try
            {
                var TaskMapped = _mapper.Map<TaskDto>(Task);

                if (string.IsNullOrEmpty(TaskMapped.Id.ToString()))
                {
                    _context.Tasks.Add(TaskMapped);
                    await UpdateTotalItems(Task.CompanyId);
                }
                else
                {
                    _context.Tasks.Update(TaskMapped);
                }

                await _context.SaveChangesAsync();

                var mappedTask = _mapper.Map<Quiplogs.Inventory.Domain.Entities.TaskEntity>(TaskMapped);
                return new PutTaskResponse(mappedTask, true, null);
            }
            catch (SqlException ex)
            {
                return new PutTaskResponse(null, false, new[] { new Error("", $"Error updating Task. {ex.Message}") });
            }
        }

        public async Task<RemoveTaskResponse> Remove(Guid id)
        {
            try
            {
                var Task = _context.Tasks.FirstOrDefault(x => x.Id == id);

                _context.Remove(Task);
                await _context.SaveChangesAsync();

                return new RemoveTaskResponse(id.ToString(), true, null);
            }
            catch (SqlException ex)
            {
                return new RemoveTaskResponse(null, false, new[] { new Error("", $"Error removing Task. {ex.Message}") });
            }
        }

        public async Task<int> GetTotalRecords(Guid companyId)
        {
            var _cacheKey = $"Task-total-{companyId}";
            var cachedTotal = await _cache.GetAsnyc<int>(_cacheKey);

            if (cachedTotal == 0)
            {
                await UpdateTotalItems(companyId);
            }

            return cachedTotal;
        }

        private async Task UpdateTotalItems(Guid companyId)
        {
            await _cache.SetAsnyc($"Task-total-{companyId}", _context.Tasks.Count());
        }
    }
}
