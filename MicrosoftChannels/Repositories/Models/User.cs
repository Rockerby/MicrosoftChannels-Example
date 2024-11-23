﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftChannels.Repositories.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public User(Guid id)
        {
            Id = id;
        }
    }
}