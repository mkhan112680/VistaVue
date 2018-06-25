using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using VistaDM.Data;
using VistaDM.Web.Models;

namespace VistaDM.Web.Controllers
{
    public class ProvinceController : BaseController
    {
        //public List<SelectListItem> GetList()
        //{
        //    List<SelectListItem> retLst = new List<SelectListItem>();

        //    foreach (var item in Entites.Provinces.Select(p => new ProvinceModel() { ID = p.ID, Name = p.name, FullName = p.FullName }).ToList())
        //    {
        //        retLst.Add
        //            (
        //                new SelectListItem()
        //                {
        //                    Value = item.ID.ToString(),
        //                    Text = item.Name
        //                }
        //            );
        //    }
        //    return retLst;
        //}

        public List<ProvinceModel> GetList()
        {
            return Entites.Provinces.Select(p => new ProvinceModel() { ID = p.ID, Name = p.name, FullName = p.FullName }).ToList();
        }

    }
}