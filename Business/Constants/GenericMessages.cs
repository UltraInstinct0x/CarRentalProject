using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Business.Constants
{
    public static class GenericMessages<T> where T : class, IEntity, new()
    {
        public static string ObjHandler = new T().GetType().Name;
    }
}
