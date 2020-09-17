using Newtonsoft.Json;

namespace TariffComparison.Model
{
    public class BaseModel : BaseModel<object>
    {
        public BaseModel()
        {

        }

        public BaseModel(bool success, object data = null, string message = "", int total = 0) : base(success, data, message, total)
        {
        }

        public static BaseModel Create(bool success, object data = null, string message = "", int total = 0)
        {
            return new BaseModel() { success = success, data = data, message = message, total = total };
        }

        public static BaseModel Error(string message, object data = null, int total = 0)
        {
            return new BaseModel(false, data, message, total);
        }

        public static BaseModel Success(object data = null, int total = 0, string message = "")
        {
            return new BaseModel(true, data, message, total);
        }

        public string ToJsonString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class BaseModel<T> where T : class
    {
        public bool success { get; set; }
        public T data { get; set; }
        public string message { get; set; }
        public int total { get; set; }

        public BaseModel()
        {

        }

        public BaseModel(bool success, T data = null, string message = "", int total = 0)
        {
            this.success = success;
            this.data = data;
            this.message = message;
            this.total = total;
        }

        public static explicit operator BaseModel<T>(BaseModel model)
        {
            return new BaseModel<T>(model.success, model.data as T, model.message, model.total);
        }
    }
}
