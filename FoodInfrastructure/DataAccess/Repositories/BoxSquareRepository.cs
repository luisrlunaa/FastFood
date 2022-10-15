using FastFood.Infrastructure.DataAccess.Contexts;
using FastFood.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFood.Infrastructure.DataAccess.Repositories
{
    public class BoxSquareRepository
    {
        DataManager Data = new DataManager();
        public (BoxSquare, string) GetBoxSquareByDate(DateTime datein)
        {
            var boxSquare = new BoxSquare();
            try
            {
                var classKeys = Data.GetObjectKeys(new BoxSquare());
                var sql = Data.SelectExpression("BoxSquare", classKeys, WhereExpresion: "WHERE DateIn = '" + datein.ToShortDateString() + "'");
                var (dr, message1) = Data.GetOne(sql, "BoxSquareRepository.GetBoxSquareByDate");
                if (dr is null)
                    return (boxSquare, message1);

                boxSquare.Id = dr.GetInt32(dr.GetOrdinal("Id"));
                boxSquare.Description = dr.GetString(dr.GetOrdinal("Description"));
                boxSquare.Amount = dr.GetDecimal(dr.GetOrdinal("Amount"));
                boxSquare.DateIn = dr.GetDateTime(dr.GetOrdinal("DateIn"));

                return (boxSquare, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (boxSquare, "Error al Cargar Data, Metodo BoxSquareRepository.GetBoxSquareByDate \n" + ex.Message.ToString());
            }
        }

        public (bool, string) AddBoxSquare(BoxSquare input)
        {
            try
            {
                if (input == null || input.DateIn == DateTime.MinValue)
                    return (false, "Error Input Invalido, Metodo BoxSquareRepository.AddBoxSquare");

                var parameters = new List<string> { "'" + input.Description + "'", "'" + input.Amount + "'", "'" + input.DateIn.ToShortDateString() + "'" };
                var classKeys = Data.GetObjectKeys(new BoxSquare()).Where(x => x != "Id").ToList();
                var sql = Data.InsertExpression("BoxSquare", classKeys, parameters);
                var (response, message) = Data.CrudAction(sql, "BoxSquareRepository.AddBoxSquare");
                if (!response)
                    return (response, message);

                return (response, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (false, "Error al Cargar Data, Metodo BoxSquareRepository.AddBoxSquare \n" + ex.Message.ToString());
            }
        }

        public (bool, string) UpdateBoxSquare(BoxSquare input)
        {
            try
            {
                if (input == null)
                    return (false, "Error Input Invalido, Metodo BoxSquareRepository.UpdateBoxSquare");

                var parameters = new List<string> { "'" + input.Description + "'", "'" + input.Amount + "'" };
                var classKeys = Data.GetObjectKeys(new BoxSquare()).Where(x => x != "Id" && x != "DateIn").ToList();

                var sql = Data.UpdateExpression("BoxSquare", classKeys, parameters, " WHERE Id = " + input.Id);
                var (response, message) = Data.CrudAction(sql, "BoxSquareRepository.UpdateBoxSquare");
                if (!response)
                    return (response, message);

                return (true, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (false, "Error al Cargar Data, Metodo BoxSquareRepository.UpdateBoxSquare \n" + ex.Message.ToString());
            }
        }
    }
}
