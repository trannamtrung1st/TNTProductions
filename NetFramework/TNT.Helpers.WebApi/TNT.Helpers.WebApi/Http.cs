using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TNT.Helpers.WebApi
{
    public static class Http
    {
        public static HttpResponseMessage Response<T>(
            HttpStatusCode status,
            T obj = default(T),
            string reasonPhrase = null)
        {
            return new HttpResponseMessage()
            {
                Content = obj != null ? new JsonContent<T>(obj) : null,
                StatusCode = status,
                ReasonPhrase = reasonPhrase
            };
        }

        public static HttpResponseMessage Response(
            HttpStatusCode status,
            object obj = null,
            string reasonPhrase = null)
        {
            return new HttpResponseMessage()
            {
                Content = obj != null ? new JsonContent(obj) : null,
                StatusCode = status,
                ReasonPhrase = reasonPhrase
            };
        }

        public static HttpResponseMessage Ok<T>(
            T obj = default(T),
            string reasonPhrase = null)
        {
            return new HttpResponseMessage()
            {
                Content = obj != null ? new JsonContent<T>(obj) : null,
                StatusCode = HttpStatusCode.OK,
                ReasonPhrase = reasonPhrase
            };
        }

        public static HttpResponseMessage Ok(
            object obj = null,
            string reasonPhrase = null)
        {
            return new HttpResponseMessage()
            {
                Content = obj != null ? new JsonContent(obj) : null,
                StatusCode = HttpStatusCode.OK,
                ReasonPhrase = reasonPhrase
            };
        }

        public static HttpResponseMessage NotFound<T>(
            T obj = default(T),
            string reasonPhrase = null)
        {
            return new HttpResponseMessage()
            {
                Content = obj != null ? new JsonContent<T>(obj) : null,
                StatusCode = HttpStatusCode.NotFound,
                ReasonPhrase = reasonPhrase
            };
        }

        public static HttpResponseMessage NotFound(
            object obj = null,
            string reasonPhrase = null)
        {
            return new HttpResponseMessage()
            {
                Content = obj != null ? new JsonContent(obj) : null,
                StatusCode = HttpStatusCode.NotFound,
                ReasonPhrase = reasonPhrase
            };
        }

        public static HttpResponseMessage Error<T>(
            T obj = default(T),
            string reasonPhrase = null)
        {
            return new HttpResponseMessage()
            {
                Content = obj != null ? new JsonContent<T>(obj) : null,
                StatusCode = HttpStatusCode.InternalServerError,
                ReasonPhrase = reasonPhrase
            };
        }

        public static HttpResponseMessage Error(
            object obj = null,
            string reasonPhrase = null)
        {
            return new HttpResponseMessage()
            {
                Content = obj != null ? new JsonContent(obj) : null,
                StatusCode = HttpStatusCode.InternalServerError,
                ReasonPhrase = reasonPhrase
            };
        }

        public static HttpResponseMessage Unauthorized<T>(
            T obj = default(T),
            string reasonPhrase = null)
        {
            return new HttpResponseMessage()
            {
                Content = obj != null ? new JsonContent<T>(obj) : null,
                StatusCode = HttpStatusCode.Unauthorized,
                ReasonPhrase = reasonPhrase
            };
        }

        public static HttpResponseMessage Unauthorized(
            object obj = null,
            string reasonPhrase = null)
        {
            return new HttpResponseMessage()
            {
                Content = obj != null ? new JsonContent(obj) : null,
                StatusCode = HttpStatusCode.Unauthorized,
                ReasonPhrase = reasonPhrase
            };
        }

        public static HttpResponseMessage BadRequest<T>(
            T obj = default(T),
            string reasonPhrase = null)
        {
            return new HttpResponseMessage()
            {
                Content = obj != null ? new JsonContent<T>(obj) : null,
                StatusCode = HttpStatusCode.BadRequest,
                ReasonPhrase = reasonPhrase
            };
        }

        public static HttpResponseMessage BadRequest(
            object obj = null,
            string reasonPhrase = null)
        {
            return new HttpResponseMessage()
            {
                Content = obj != null ? new JsonContent(obj) : null,
                StatusCode = HttpStatusCode.BadRequest,
                ReasonPhrase = reasonPhrase
            };
        }

    }
}
