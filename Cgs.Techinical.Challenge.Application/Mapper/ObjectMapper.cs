﻿

using Cds.Technical.Challenge.Application.Contracts.Mapper;

namespace Cgs.Techinical.Challenge.Application.Mapper
{
    public class ObjectMapper: IObjectMapper
    {
        public TDestination Map<TSource, TDestination>(TSource sourceObject)
        {
            var destinationObject = Activator.CreateInstance<TDestination>();
            if (sourceObject != null)
            {
                foreach (var sourceProperty in typeof(TSource).GetProperties())
                {
                    var destinationProperty =
                    typeof(TDestination).GetProperty
                    (sourceProperty.Name);
                    if (destinationProperty != null)
                    {
                        destinationProperty.SetValue
                        (destinationObject,
                       sourceProperty.GetValue(sourceObject));
                    }
                }
            }
            return destinationObject;
        }
    }
}
