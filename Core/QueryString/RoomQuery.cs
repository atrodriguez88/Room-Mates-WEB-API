﻿using RoomM.API.Common.MyExtensions;

namespace RoomM.API.Core.QueryString
{
    public class RoomQuery : IQuerySort, IQueryPage
    {
        //        Filtering
        public string Address { get; set; }
        public int? PropertyId { get; set; }
        public int? NumberBedrooms { get; set; }
        public int? NumberBathrooms { get; set; }
        public float? RentPerMonth { get; set; }
        public int? IsUtilityIncluded { get; set; }
        public string RoomType { get; set; }            // Single Room, Double, Shared
        public float? RoomSquareMeters { get; set; }
        public int? IsFurnished { get; set; }
        public int? MinStayMonths { get; set; }

        public string Smoking { get; set; }
        public string Pet { get; set; }             // Dog(s) ok, Cat(s) ok, Caged Pet(s) ok,
        public string Cleanliness { get; set; }

        //        Sorting

        /*  Create to IQuerySort for clean arquitecture */

        public string SortBy { get; set; }
        public bool IsSortAsc { get; set; }

        // Pagining
        public int Page { get; set; }
        public byte PageSize { get; set; }
    }
}
