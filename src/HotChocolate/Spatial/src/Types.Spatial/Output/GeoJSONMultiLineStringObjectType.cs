﻿using System.Collections.Generic;
using HotChocolate;
using HotChocolate.Types;
using NetTopologySuite.Geometries;
using Types.Spatial.Common;

namespace Types.Spatial.Output
{
    public class GeoJSONMultiLineStringObjectType : ObjectType<MultiLineString>
    {
        protected override void Configure(IObjectTypeDescriptor<MultiLineString> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Implements<GeoJSONInterface>();

            descriptor.Field("type").Resolver(GeoJSONGeometryType.MultiLineString);
            descriptor.Field(x => x.Coordinates);
            descriptor.Field<Resolver>(x => x.GetBbox(default!));
        }

        internal class Resolver
        {
            public IReadOnlyCollection<double> GetBbox([Parent] MultiLineString geometry)
            {
                var envelope = geometry.EnvelopeInternal;

                // TODO: support Z
                return new[] { envelope.MinX, envelope.MinY, envelope.MaxX, envelope.MaxY };
            }
        }
    }

    public class GeoJSONMultiLineStringObjectExtensionType : ObjectTypeExtension<MultiLineString>
    {
        protected override void Configure(IObjectTypeDescriptor<MultiLineString> descriptor)
        {
            descriptor.BindFieldsExplicitly();
            descriptor.Field<CrsResolvers>(x => x.GetCrs(default!));
        }
    }
}