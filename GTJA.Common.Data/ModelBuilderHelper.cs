using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GTJA.Common.Data
{
    public static class ModelBuilderHelper
    {
        public static void LoadModel(DbModelBuilder modelBuilder, string modelMapAssemblyString)
        {
            var typesToRegister = Assembly.Load(modelMapAssemblyString).GetTypes()
            .Where(type => !String.IsNullOrEmpty(type.Namespace))
                .Where(
                    type =>
                        type.BaseType != null && type.BaseType.IsGenericType &&
                        type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
        }
    }
}
