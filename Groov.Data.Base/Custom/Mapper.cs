using Groov.Data.Base.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Groov.Data.Base.Enums.CommonEnums;

namespace Groov.Data.Base.Custom
{
    /// <summary>
    /// Copy the values from a object to another
    /// Source: https://stackoverflow.com/questions/930433/apply-properties-values-from-one-object-to-another-of-the-same-type-automaticall
    /// </summary>
    public static class Mapper
    {
        public static void CopyProperties(this object source, object destination)
        {
            try
            {
                // If any this null throw an exception
                if (source == null || destination == null)
                    throw new Exception("El objeto base y/o destino son null.");

                // Getting the Types of the objects
                var typeDest = destination.GetType();
                var typeSrc = source.GetType();

                // Iterate the Properties of the source instance and  
                // populate them from their desination counterparts  
                var srcProps = typeSrc.GetProperties();
                foreach (PropertyInfo srcProp in srcProps)
                {
                    if (!srcProp.CanRead)
                        continue;

                    PropertyInfo targetProperty = typeDest.GetProperty(srcProp.Name);

                    // Test all the posibilities
                    if (targetProperty == null)
                        continue;

                    if (!targetProperty.CanWrite)
                        continue;

                    if (targetProperty.GetSetMethod(true) != null && targetProperty.GetSetMethod(true).IsPrivate)
                        continue;

                    if ((targetProperty.GetSetMethod().Attributes & MethodAttributes.Static) != 0)
                        continue;

                    if (!targetProperty.PropertyType.IsAssignableFrom(srcProp.PropertyType))
                        continue;

                    // Passed all tests, lets set the value
                    targetProperty.SetValue(destination, srcProp.GetValue(source, null), null);
                }
            }catch(Exception ex)
            {
                ApplicationLog.LogError(ex, ErrorCode.Projection, "CopyProperties()");
            }
        }

    }
}
