using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessRefactor.API.Attributes;
using DataAccessRefactor.API.DataSourceAccessers;
using DataAccessRefactor.API.Enums;

namespace DataAccessRefactor.API.Static_classes
{
    public class DataSourceAccesserFactory
    {
        private Dictionary<AccesserType, IDataSourceAccesser> Accessers { get; }

        private static DataSourceAccesserFactory _instance;

        public static DataSourceAccesserFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DataSourceAccesserFactory();
                }

                return _instance;
            }
        }


        private DataSourceAccesserFactory()
        {
            Accessers = new Dictionary<AccesserType, IDataSourceAccesser>();
        }

        public IDataSourceAccesser GetAccesserForSource(AccesserType source)
        {
            if (Accessers.Count == 0)
            {
                Type interfaceType = typeof(IDataSourceAccesser);
                Type attributeType = typeof(DataSourceAccesserAttribute);

                var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(assembly => assembly.GetTypes())
                    .Where(t => interfaceType.IsAssignableFrom(t) && !t.IsInterface).ToArray();

                var attributes = types.SelectMany(type =>
                    type.GetCustomAttributes(attributeType, false)).ToArray();

                for (int i = 0; i < types.Count(); i++)
                {
                    var attribute = (DataSourceAccesserAttribute) attributes[i];
                    var accesser = (IDataSourceAccesser) Activator.CreateInstance(types[i]);
                    Accessers.Add(attribute.AccesserType, accesser);
                }
            }

            return Accessers[source];
        }
    }
}