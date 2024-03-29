﻿using Vee_Tailoring.Models.DTOs;
namespace Vee_Tailoring.Interfaces.Services;

public interface IColorService
{
    Task<BaseResponse> Create(CreateColorDto createColorDto);
    Task<BaseResponse> Update(int id, UpdateColorDto updateColorDto);
    Task<ColorResponseModel> GetById(int id);
    Task<ColorsResponseModel> GetByColorName(string colorName);
    Task<ColorsResponseModel> GetByColorCode(string colorCode);
    Task<ColorsResponseModel> GetAllColor();
    Task<DashBoardResponse> ColorDashboard();
    Task<BaseResponse> DeActivateColor(int id);
}