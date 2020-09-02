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

        public IActionResult MoreFirstAlgorithm() {
            return View();
        }

        public IActionResult LessFirstAlgorithm() {
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

        public ObjectResult TraditionalCurrentTurn() {
            return new Response<object> {
                Code = 0,
                Data = new {
                    NeteaseMusicShuffle.Program.TraditionalAlgorithm.CurrentTurn,
                    NeteaseMusicShuffle.Program.TraditionalAlgorithm.EveryTurnMusicCount
                }
            }.ToObjectResult();
        }

        public ObjectResult MoreFirstNextTurn() {
            var data = NeteaseMusicShuffle.Program.MoreFirstAlgorithm.NextTurn();

            return new Response<object> {
                Code = 0,
                Data = new {
                    NeteaseMusicShuffle.Program.MoreFirstAlgorithm.CurrentTurn,
                    List = data.Select((item) => new {
                        Title = item.Key,
                        PlayedTimes = item.Value
                    }).ToList()
                }
            }.ToObjectResult();
        }

        public ObjectResult MoreFirstCurrentPlay() {
            var playList = NeteaseMusicShuffle.Program.MoreFirstAlgorithm.PlayList;

            return new Response<object> {
                Code = 0,
                Data = playList.Select((item) => new {
                    Title = item.Key,
                    PlayedTimes = item.Value
                }).ToList()
            }.ToObjectResult();
        }

        public ObjectResult MoreFirstCurrentTurn() {
            return new Response<object> {
                Code = 0,
                Data = new {
                    NeteaseMusicShuffle.Program.MoreFirstAlgorithm.CurrentTurn,
                    NeteaseMusicShuffle.Program.MoreFirstAlgorithm.EveryTurnMusicCount
                }
            }.ToObjectResult();
        }

        public ObjectResult LessFirstNextTurn() {
            var data = NeteaseMusicShuffle.Program.LessFirstAlgorithm.NextTurn();

            return new Response<object> {
                Code = 0,
                Data = new {
                    NeteaseMusicShuffle.Program.LessFirstAlgorithm.CurrentTurn,
                    List = data.Select((item) => new {
                        Title = item.Key,
                        PlayedTimes = item.Value
                    }).ToList()
                }
            }.ToObjectResult();
        }

        public ObjectResult LessFirstCurrentPlay() {
            var playList = NeteaseMusicShuffle.Program.LessFirstAlgorithm.PlayList;

            return new Response<object> {
                Code = 0,
                Data = playList.Select((item) => new {
                    Title = item.Key,
                    PlayedTimes = item.Value
                }).ToList()
            }.ToObjectResult();
        }

        public ObjectResult LessFirstCurrentTurn() {
            return new Response<object> {
                Code = 0,
                Data = new {
                    NeteaseMusicShuffle.Program.LessFirstAlgorithm.CurrentTurn,
                    NeteaseMusicShuffle.Program.LessFirstAlgorithm.EveryTurnMusicCount
                }
            }.ToObjectResult();
        }
    }
}