﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        List<Color> GetAll();
        Color GetAllById(int colorId);
        void Add(Color color);
        void Update(Color color);
        void Delete(Color color);
    }
}
