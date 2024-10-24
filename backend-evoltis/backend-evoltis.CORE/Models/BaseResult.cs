using System.Net;

namespace backend_evoltis.CORE.Models
{
    public class BaseResult
    {
        public string Error { get; set; } = "";
        public bool Ok { get; set; } = true;
        public string MensajeInfo { get; set; } = "";
        public List<string> ListaMensajeInfo { get; set; } = new();
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;

        public void SetError()
        {
            Ok = false;
            Error = "Error procesando la solicitud";
            StatusCode = HttpStatusCode.InternalServerError;
        }

        public void SetError(string error, HttpStatusCode statusCode)
        {
            Ok = false;
            Error = error;
            StatusCode = statusCode;
        }
    }
}
