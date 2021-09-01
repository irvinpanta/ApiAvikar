using Api.Core.Exceptions;
using Api.Models;
using Api.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.Repositories
{
    public class MesaRepository : IBaseRepository<MesaModel>
    {
        private readonly SisAvikarDemoContext _context;
        private string message;

        public MesaRepository(SisAvikarDemoContext conext)
        {
            _context = conext;
        }
        public async Task<IEnumerable<MesaModel>> GetAll()
        {
            //var sql = from mesa in _context.Mesas
            //          join salon in _context.Salones on mesa.Salon equals salon.Id
            //          select new MesaModel
            //          {
            //              Id = mesa.Id,
            //              Descripcion = mesa.Descripcion,
            //              Cantidad = mesa.Cantidad,
            //              Activo = mesa.Activo,
            //              FecSistema = mesa.FecSistema,
            //              MesaRapida = mesa.MesaRapida,
            //              Salon = mesa.Salon,
            //              Salones = new SalonModel
            //              {
            //                  Id = salon.Id,
            //                  Descripcion = salon.Descripcion,
            //                  //Capacidad = salon.Capacidad,
            //                  //Activo = salon.Activo
            //              }
            //          };
            //var response = await sql.ToListAsync();
           
            var response = await _context.Mesas.ToListAsync();

            //var response = await _context.Mesas
            //                        .Join(_context.Salones, 
            //                        mesa => mesa.Salon, 
            //                        salon => salon.Salon, 
            //                        (mesa, salon) => new MesaModel {  
            //                            Descripcion = mesa.Descripcion
            //                        }).Select(x=> x.Descripcion).ToListAsync();



            return response;
        } 

        public async Task<MesaModel> GetById(int id)
        {
            var sql = from mesa in _context.Mesas
                      join salon in _context.Salones on mesa.Salon equals salon.Id
                      select new MesaModel
                      {
                          Id = mesa.Id,
                          Descripcion = mesa.Descripcion,
                          Cantidad = mesa.Cantidad,
                          Activo = mesa.Activo,
                          FecSistema = mesa.FecSistema,
                          MesaRapida = mesa.MesaRapida,
                          Salon = mesa.Salon,
                          Salones = new SalonModel
                          {
                              Id = salon.Id,
                              Descripcion = salon.Descripcion,
                              //Capacidad = salon.Capacidad,
                              //Activo = salon.Activo
                          }
                      };

            var response = await sql.FirstOrDefaultAsync(x => x.Id == id);

            //var response = await _context.Mesas.FirstOrDefaultAsync(x => x.Mesa == id);

            return response;
        }

        public async Task<string> Save(MesaModel entity)
        {
            try
            {
                await _context.Mesas.AddAsync(entity);
                int n = _context.SaveChanges();

                if (n != 0){
                    message = "MSG_0001";
                }else{
                    message = "MSG_ERROR";
                }

                return message; //Retornamos un message
            
            }catch(Exception ex){
                return ex.Message;
            }finally{
                _context.Dispose();
            }     
        }

        public async Task<string> Update(MesaModel entity)
        {
            try
            {

                int n;
                //if (!(_context.Mesas.Any(x=>x.Descripcion.Equals(entity.Descripcion) && x.Mesa != entity.Mesa))){

                _context.Mesas.Update(entity);
                n = await _context.SaveChangesAsync();

                //}else{
                //    message = "Registro ya existe";
                //}

                if (n != 0){
                    message = "MSG_0002";
                }else{
                    message = "MSG_ERROR";
                }

                return message; //Retornamos una respuesta

            }catch (Exception ex){
                return ex.Message;
            }finally{
                _context.Dispose();
            }

        }

        public async Task<string> Delete(int id)
        {
            try
            {
                var model = await _context.Mesas.FindAsync(id);
                _context.Mesas.Remove(model);

                int n = _context.SaveChanges();

                if (n != 0){
                    message = "MSG_0003";
                }else{
                    message = "MSG_ERROR";
                }

                return message; //Retornamos un message

            }catch (Exception ex){
                return message = ex.Message;
            }finally{
                _context.Dispose();
            }

        }

        public bool ExistsByDescripcion(string descripcion)
        {
            return _context.Mesas.Any(x => x.Descripcion.Equals(descripcion));
        }

        public bool ExistsById(int id)
        {
            return _context.Mesas.Any(x => x.Id == id);
        }
    }
}
