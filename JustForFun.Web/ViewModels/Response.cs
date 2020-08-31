using Microsoft.AspNetCore.Mvc;

namespace JustForFun.Web.ViewModels {
    public class Response<T> {
        public int Code { get; set; }
        public string Msg { get; set; }
        public int Count { get; set; }
        public T Data { get; set; }

        public ObjectResult ToObjectResult() => new ObjectResult(this);
    }
}