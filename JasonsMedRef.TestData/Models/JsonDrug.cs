﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Jaxosoft.TestData
{
    public class JsonDrug : IEquatable<JsonDrug>
    {
        // these 4 fields are the "primary key", if you will
        public string Ingredient { get; set; }
        [JsonConverter(typeof(NullableIntEnumConverter))]
        public RouteOfAdministration? Route { get; set; }
        [JsonConverter(typeof(NullableIntEnumConverter))]
        public DosageForm? DosageForm { get; set; }
        [JsonConverter(typeof(NullableIntEnumConverter))]
        public DrugType? DrugType { get; set; }

        [JsonConverter(typeof(NullableIntEnumConverter))]
        public DrugSchedule? Schedule { get; set; }
        public DateTime? StartMarketingDate { get; set; }
        public DateTime? EndMarketingDate { get; set; }
        [JsonConverter(typeof(NullableIntEnumConverter))]
        public MarketingCategory? MarketingCategory { get; set; }

        public List<string> Strengths { get; set; } = new List<string>();
        public List<string> TradeNames { get; set; } = new List<string>();
        public List<JsonPharmaClass> PharmaClasses { get; set; } = new List<JsonPharmaClass>();

        public List<JsonApplication> Applications { get; set; } = new List<JsonApplication>();

        public override bool Equals(object obj)
        {
            return Equals(obj as JsonDrug);
        }

        public bool Equals(JsonDrug other)
        {
            return other != null &&
                   Ingredient.ToLowerInvariant() == other.Ingredient.ToLowerInvariant() &&
                   EqualityComparer<RouteOfAdministration?>.Default.Equals(Route, other.Route) &&
                   EqualityComparer<DosageForm?>.Default.Equals(DosageForm, other.DosageForm) &&
                   EqualityComparer<DrugType?>.Default.Equals(DrugType, other.DrugType);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Ingredient.ToLower(), Route, DosageForm, DrugType);
        }
    }
}