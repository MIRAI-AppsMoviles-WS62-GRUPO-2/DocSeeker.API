﻿using Docseeker.API.Profiles.Domain.Models;
using DocSeeker.API.Shared.Domain.Services.Communication;

namespace Docseeker.API.Profiles.Domain.Services.Communication;

public class DoctorResponse : BaseResponse<Doctor>
{
    public DoctorResponse(string message) : base(message)
    {
    }

    public DoctorResponse(Doctor resource) : base(resource)
    {
    }
}