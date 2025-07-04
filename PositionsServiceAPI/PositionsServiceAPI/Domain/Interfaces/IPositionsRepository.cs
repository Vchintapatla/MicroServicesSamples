﻿using PositionsServiceAPI.Infrastructure.Data;
using RatesServiceAPI.Infrastrucutre.Data;

namespace PositionsServiceAPI.Domain.Interfaces
{
	public interface IPositionsRepository
	{
		Task<IEnumerable<Position>> GetPositionsAsync();
		Task UpdatePositionAsync(ExchangeRate updatedRate);
	}
}
