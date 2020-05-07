using HotChocolate.Types;
using NetTopologySuite.Geometries;
using Types.Spatial.Common;

namespace Types.Spatial.Output
{
    public class GeoJSONInterface: InterfaceType
    {
        protected override void Configure(IInterfaceTypeDescriptor descriptor)
        {
            base.Configure(descriptor);
            descriptor.Field("type")
                .Type<NonNullType<EnumType<GeoJSONGeometryType>>>()
                .Description("Type of the GeoJSON Object");

            descriptor.Field("bbox")
                .Type<ListType<FloatType>>();

            // TODO: Add crs: CoordinateReferenceSystemObject
        }
    }
}
