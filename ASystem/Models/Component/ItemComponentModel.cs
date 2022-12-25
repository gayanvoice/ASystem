namespace ASystem.Models.Component
{
    public class ItemComponentModel
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public RouteModel Route { get; set; }

        public class RouteModel
        {
            public string Controller { get; set; }
            public string Action { get; set; }
        }
    }
}