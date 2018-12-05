using System;
using System.Collections.Generic;
using System.Text;
using CsvHelper.Configuration;

namespace JasonsMedRef.Importer.Maps
{
    public class PharmaClassMap : ClassMap<PharmaClass>
    {
        public PharmaClassMap()
        {
            Map(m => m.UniqueIdentifier).Index(0);
            Map(m => m.Name).Index(1);
            Map(m => m.Classification).Index(2).TypeConverter<NullableEnumConverter>();
            Map(m => m.ClassificationText).Index(2);
        }
    }
}
