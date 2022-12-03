using BusTicket.Business.Abstract;
using BusTicket.Data.Abstract;
using BusTicket.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Business.Concreate
{
    public class LineManager: ILineService
    {
        private readonly ILineRepository _lineRepository;

        public LineManager(ILineRepository lineRepository)
        {
            _lineRepository = lineRepository;
        }

        public async Task CreateAsync(Line line)
        {
            await _lineRepository.CreateAsync(line);
        }

        public async Task DeleteAsync(Line line)
        {
            await _lineRepository.DeleteAsync(line);
        }

        public async Task<List<Line>> GetAllAsync()
        {
            return await _lineRepository.GetAllAsync();
        }

        public async Task<Line> GetByIdAsync(int id)
        {
            return await _lineRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Line line)
        {
            await _lineRepository.UpdateAsync(line);
        }

        public async Task<List<Line>> GetLinesBySearchAsync(string from, string to)
        {
            return await _lineRepository.GetLinesBySearchAsync(from, to);
        }

        public async Task<List<Line>> GetLinesWithTripsAsync()
        {
           return await _lineRepository.GetLinesWithTripsAsync();
        }

        public async Task<Line> GetLineWithDetailsAsync(int id)
        {
            return await _lineRepository.GetLineWithDetailsAsync(id);
        }
    }
}
