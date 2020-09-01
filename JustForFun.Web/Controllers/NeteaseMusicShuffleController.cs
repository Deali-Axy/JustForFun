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

        public IActionResult TraditionalAlgorithm() {
            return View();
        }

        public IActionResult ImproveAlgorithm() {
            return View();
        }

        public ObjectResult TraditionalNextTurn() {
            var data = NeteaseMusicShuffle.Program.TraditionalAlgorithm.NextTurn();

            return new Response<object> {
                Code = 0,
                Data = new {
                    NeteaseMusicShuffle.Program.TraditionalAlgorithm.CurrentTurn,
                    List = data.Select((item) => new {
                        Title = item.Key,
                        PlayedTimes = item.Value
                    }).ToList()
                }
            }.ToObjectResult();
        }

        public ObjectResult TraditionalCurrentPlay() {
            var playList = NeteaseMusicShuffle.Program.TraditionalAlgorithm.PlayList;

            return new Response<object> {
                Code = 0,
                Data = playList.Select((item) => new {
                    Title = item.Key,
                    PlayedTimes = item.Value
                }).ToList()
            }.ToObjectResult();
        }

        public ObjectResult ImproveNextTurn() {
            var data = NeteaseMusicShuffle.Program.ImproveAlgorithm.NextTurn();

            return new Response<object> {
                Code = 0,
                Data = new {
                    NeteaseMusicShuffle.Program.ImproveAlgorithm.CurrentTurn,
                    List = data.Select((item) => new {
                        Title = item.Key,
                        PlayedTimes = item.Value
                    }).ToList()
                }
            }.ToObjectResult();
        }

        public ObjectResult ImproveCurrentPlay() {
            var playList = NeteaseMusicShuffle.Program.ImproveAlgorithm.PlayList;

            return new Response<object> {
                Code = 0,
                Data = playList.Select((item) => new {
                    Title = item.Key,
                    PlayedTimes = item.Value
                }).ToList()
            }.ToObjectResult();
        }
    }
}