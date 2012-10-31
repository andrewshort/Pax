using PaxService.Model.Attributes;
using PaxService.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaxService.Model.Enum
{
    public enum EventType
    {
        [StringValue("X")]
        GeofenceEnter,

        [StringValue("T")]
        TamperDetection,

        [StringValue("H")]
        PowerStatus,

        [StringValue("F")]
        Roaming,

        [StringValue("E")]
        HomeNetwork,

        [StringValue("8")]
        AccidentShock,

        [StringValue("7")]
        InstanceGeofenceExit,

        [StringValue("6")]
        OverSpeed,

        [StringValue("4")]
        GeofenceExit,

        [StringValue("3")]
        SOS,

        [StringValue("1")]
        SOSV3,

        [StringValue("0")]
        RegularWaypoint,

        Unknown
    }

    public interface IEventTypeParser
    {
        EventType GetEventType(IAvrmcObject avrmc);
    }

    public class EventTypeParser: IEventTypeParser
    {

        public EventType GetEventType(IAvrmcObject avrmc)
        {
            var type = typeof(EventType);

            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description == avrmc.EventCode)
                        return (EventType)field.GetValue(null);
                }
                else
                {
                    if (field.Name == avrmc.EventCode)
                        return (EventType)field.GetValue(null);
                }
            }
            return EventType.Unknown;
        }
    }
}
