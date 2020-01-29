using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Api.Core.Domain;
using Api.Presenters;
using Api.Serialization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        // GET: api/Equipment
        [HttpGet]
        public ActionResult Get(int page)
        {
            const int pageSize = 4;

            var ContentResult = new JsonContentResult();
            List<Equipment> equipList = new List<Equipment>();

            equipList.Add(new Equipment(new Guid(), "equip1", "description1", "walvis bay", 365, "H", 0));
            equipList.Add(new Equipment(new Guid(), "equip2", "description2", "walvis bay", 41, "KM", 0));
            equipList.Add(new Equipment(new Guid(), "equip3", "description3", "walvis bay", 86, "H", 0));
            equipList.Add(new Equipment(new Guid(), "equip4", "description4", "walvis bay", 7, "H", 0));
            equipList.Add(new Equipment(new Guid(), "equip5", "description5", "walvis bay", 12, "H", 0));
            equipList.Add(new Equipment(new Guid(), "equip6", "description6", "walvis bay", 1111, "H", 0));
            equipList.Add(new Equipment(new Guid(), "equip7", "description7", "walvis bay", 459, "H", 0));
            equipList.Add(new Equipment(new Guid(), "equip8", "description8", "walvis bay", 758, "H", 0));
            equipList.Add(new Equipment(new Guid(), "equip9", "description9", "walvis bay", 44, "KM", 0));
            equipList.Add(new Equipment(new Guid(), "equip10", "description10", "walvis bay", 59, "KM", 0));
            equipList.Add(new Equipment(new Guid(), "equip11", "description11", "walvis bay", 966, "H", 0));
            equipList.Add(new Equipment(new Guid(), "equip12", "description12", "walvis bay", 35, "H", 0));
            equipList.Add(new Equipment(new Guid(), "equip13", "description13", "walvis bay", 3675, "KM", 0));
            equipList.Add(new Equipment(new Guid(), "equip14", "description14", "walvis bay", 786, "H", 0));
            equipList.Add(new Equipment(new Guid(), "equip15", "description15", "walvis bay", 567, "H", 0));
            equipList.Add(new Equipment(new Guid(), "equip16", "description16", "walvis bay", 4658, "H", 0));
            equipList.Add(new Equipment(new Guid(), "equip17", "description17", "walvis bay", 456, "H", 0));
            equipList.Add(new Equipment(new Guid(), "equip18", "description18", "walvis bay", 55, "H", 0));
            equipList.Add(new Equipment(new Guid(), "equip19", "description19", "walvis bay", 456, "KM", 0));
            equipList.Add(new Equipment(new Guid(), "equip20", "description20", "walvis bay", 665, "KM", 0));
            equipList.Add(new Equipment(new Guid(), "equip21", "description21", "walvis bay", 665, "KM", 0));
            equipList.Add(new Equipment(new Guid(), "equip22", "description22", "walvis bay", 665, "KM", 0));


            var pagedItems = new PagedResult<Equipment>(equipList.Skip((page - 1) * pageSize).Take(pageSize).ToList(), equipList.Count, page, pageSize);

            ContentResult.StatusCode = (int)HttpStatusCode.OK;
            ContentResult.Content = JsonSerializer.SerializeObject(pagedItems);
            return ContentResult;
        }
    }

    public class Equipment
    {
        public Guid Id { get; }

        public string Code { get; }

        public string Description { get; }

        public string Location { get; }

        public decimal CurrentWorkDone { get; }

        public string UoM { get; }

        public decimal WorkDoneToday { get; }

        public Equipment(Guid id, string code, string description, string location, decimal currentWorkDone, string uoM, decimal workDoneToday)
        {
            Id = id;
            Code = code;
            Description = description;
            Location = location;
            CurrentWorkDone = currentWorkDone;
            UoM = uoM;
            WorkDoneToday = workDoneToday;
        }
    }
}
