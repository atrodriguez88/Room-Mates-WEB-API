﻿namespace RoomM.API.Controllers.Resources
{
    public class PhotoResource
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public bool IsAvatar { get; set; } = false;
    }
}
