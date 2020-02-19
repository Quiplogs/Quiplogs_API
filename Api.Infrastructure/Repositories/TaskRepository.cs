using Api.Core;
using Api.Core.Dto;
using Api.Core.Dto.Repositories.Task;
using Api.Core.Helpers;
using Api.Core.Interfaces.Repositories;
using Api.Infrastructure.Data.Entities;
using Api.Infrastructure.SqlContext;
using AutoMapper;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Infrastructure.Repositories
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

        public async Task<ListTaskResponse> List(string companyId,  int pageNumber, int pageSize)
        {
            try
            {
                var TaskList = _context.Tasks.Where(x =>
                    x.CompanyId == companyId)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize).ToList();

                List<Core.Domain.Entities.TaskEntity> mappedTask = _mapper.Map<List<Core.Domain.Entities.TaskEntity>>(TaskList);
                return new ListTaskResponse(mappedTask, true, null);
            }
            catch (SqlException ex)
            {
                return new ListTaskResponse(null, false, new[] { new Error(GlobalVariables.error_taskFailure, $"Error fetching Task. {ex.Message}") });
            }
        }

        public async Task<GetTaskResponse> Get(string id)
        {
            try
            {
                var Task = _context.Tasks.FirstOrDefault(x => x.Id == id);

                Core.Domain.Entities.TaskEntity mappedTask = _mapper.Map<Core.Domain.Entities.TaskEntity>(Task);
                return new GetTaskResponse(mappedTask, true, null);
            }
            catch (SqlException ex)
            {
                return new GetTaskResponse(null, false, new[] { new Error(GlobalVariables.error_taskFailure, $"Error fetching Task. {ex.Message}") });
            }
        }

        public async Task<PutTaskResponse> Put(Core.Domain.Entities.TaskEntity Task)
        {
            try
            {
                var TaskMapped = _mapper.Map<TaskDto>(Task);

                if (string.IsNullOrEmpty(TaskMapped.Id))
                {
                    _context.Tasks.Add(TaskMapped);
                    await UpdateTotalItems(Task.CompanyId);
                }
                else
                {
                    _context.Tasks.Update(TaskMapped);
                }

                await _context.SaveChangesAsync();

                Core.Domain.Entities.TaskEntity mappedTask = _mapper.Map<Core.Domain.Entities.TaskEntity>(TaskMapped);
                return new PutTaskResponse(mappedTask, true, null);
            }
            catch (SqlException ex)
            {
                return new PutTaskResponse(null, false, new[] { new Error(GlobalVariables.error_taskFailure, $"Error updating Task. {ex.Message}") });
            }
        }

        public async Task<RemoveTaskResponse> Remove(string id)
        {
            try
            {
                var Task = _context.Tasks.FirstOrDefault(x => x.Id == id);

                _context.Remove(Task);
                await _context.SaveChangesAsync();

                return new RemoveTaskResponse(id, true, null);
            }
            catch (SqlException ex)
            {
                return new RemoveTaskResponse(null, false, new[] { new Error(GlobalVariables.error_taskFailure, $"Error removing Task. {ex.Message}") });
            }
        }

        public async Task<int> GetTotalRecords(string companyId)
        {
            var _cacheKey = $"Task-total-{companyId}";
            var cachedTotal = await _cache.GetAsnyc<int>(_cacheKey);

            if (cachedTotal == 0)
            {
                await UpdateTotalItems(companyId);
            }

            return cachedTotal;
        }

        private async Task UpdateTotalItems(string companyId)
        {
            await _cache.SetAsnyc($"Task-total-{companyId}", _context.Tasks.Count());
        }
    }
}
