using System;
using FrontoBack.Business.Interfaces;
using FrontoBack.Core.Interfaces;
using FrontoBack.DAL;
using FrontoBack.Models;
using FrontoBack.ViewModel.StreetVM;

namespace FrontoBack.Business.Services
{
	public class StreetService:IStreetService
	{
        private readonly IStreetRepozitory _streetRepozitory;

        public StreetService(IStreetRepozitory  streetRepozitory)
        {
            _streetRepozitory = streetRepozitory;
        }
        public async Task<bool> Create(CreateStreetVM createStreetVM)
        {

            try
            {
                if (await _streetRepozitory.EntityIsExist(s=>s.Name.ToLower()==createStreetVM.Name.ToLower()))
                {
                    return false;
                }

                 await _streetRepozitory.Create(new Street { Name=createStreetVM.Name,CityId=createStreetVM.CityId});
                await _streetRepozitory.Commit();
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong");
            }
        }

        public async Task<bool> Delete(int? id)
        {
            try
            {
                Street existStreet =await _streetRepozitory.GetById(s => s.Id == id);
                if (existStreet==null)
                {
                    return false;
                }

                 _streetRepozitory.Delete(existStreet);
                await _streetRepozitory.Commit();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong");
            }
        }

        public async Task<List<Street>> GetAll()
        {
            try
            {
                return await _streetRepozitory.GetAll(null, "City");
            }
            catch (Exception ex)
            {
                throw new Exception("Something want wrong");
            }
        }

        public async Task<Street> GetById(int? id)
        {
            try
            {
                return await _streetRepozitory.GetById(s => s.Id == id);

            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong");
            }
        }
        public async Task<Street> GetByIdIncludeCity(int ?id)
        {
            try
            {
                return await _streetRepozitory.GetById(s => s.Id == id, "City");
               
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong");
            }
        }
        public async Task<Street> GetByIdThenIncludeCountry(int? id)
        {
            try
            {
                return await _streetRepozitory.GetById(s => s.Id == id, "City.Country");

            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong");
            }
        }
        public async Task<bool> Update(int id,UpdateStreetVM updateStreetVM)
        {
            try
            {
                Street street = await GetByIdIncludeCity(id);
                if (await _streetRepozitory.EntityIsExist(s => s.Name.ToLower() == updateStreetVM.Name.ToLower() && s.CityId == street.CityId && updateStreetVM.Name != street.Name))
                {

                    return false;
                }
                street.Name = updateStreetVM.Name;
                await _streetRepozitory.Update(street);
                await _streetRepozitory.Commit();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong");
            }


        }
    }
}

