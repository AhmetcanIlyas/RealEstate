﻿namespace RealEstate_Dapper_UI.Dtos.ProductDtos
{
    public class ResultLast5ProductDto
    {
        public int ProductID { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string CategoryName { get; set; }
        public string TypeName { get; set; }
        public DateTime AdvertisementDate { get; set; }
    }
}
