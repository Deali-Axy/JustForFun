using System.Collections.Generic;
using System.Linq;
using JustForFun.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using NeteaseMusicShuffle;
using NeteaseMusicShuffle.Models;

namespace JustForFun.Web.Controllers {
    public class NeteaseMusicShuffleController : Controller {
        // GET
        public IActionResult Index() {
            return View();
        }

        public ObjectResult MusicList() {
            return new Response<List<SimpleMusic>> {
                Code = 0,
                Count = NeteaseMusicShuffleData.DataList.Count,
                Data = NeteaseMusicShuffleData.DataList,
                Msg = "ok"
            }.ToObjectResult();
        }

        public IActionResult PlayList() {
            return View();
        }

        public ObjectResult NextTurn() {
            var data = NeteaseMusicShuffle.Program.NextTurn();

            return new Response<object> {
                Code = 0,
                Data = new {
                    NeteaseMusicShuffle.Program.CurrentTurn,
                    List = data.Select((item) => new {
                        Title = item.Key,
                        PlayedTimes = item.Value
                    }).ToList()
                },
            }.ToObjectResult();
        }
    }
}