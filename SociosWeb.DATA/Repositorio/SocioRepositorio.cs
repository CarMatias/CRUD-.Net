using Dapper;
using Npgsql;
using SociosWeb.MODEL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


namespace SociosWeb.DATA.Repositorio
{
    public class SocioRepositorio : ISocioRepositorio
    {
        private PostgreSQLConfig _connectionString;

        public SocioRepositorio(PostgreSQLConfig conectionString)
        {
            _connectionString = conectionString;
        }
        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }


        public async Task<IEnumerable<Socio>> TodosSocios()
        {
            var db = dbConnection();

            var sql = @"
                        SELECT nombre, apellido, nrosocio, direccion, telefono, dni, foto
                        FROM public.""Socios""";



            return await db.QueryAsync<Socio>(sql, new { });
        }

        public async Task<Socio> VerSocio(int nrosocio)
        {
            var db = dbConnection();

            var sql = @"
                        SELECT nombre, apellido, nrosocio, direccion, telefono, dni, foto
                        FROM public.""Socios""
                        WHERE nrosocio = @nrosocio";



            return await db.QueryFirstOrDefaultAsync<Socio>(sql, new { nrosocio = nrosocio });


        }

        public async Task<bool> InsertarSocio(Socio socio)
        {
            var db = dbConnection();

            var sql = @"
                            INSERT INTO public.""Socios""(nombre, apellido, direccion, telefono, dni, foto)
                        VALUES(@nombre,@apellido,@direccion,@telefono,@dni, @foto)";

            var result = await db.ExecuteAsync(sql, new { socio.nombre, socio.apellido, socio.direccion, socio.telefono, socio.dni, socio.foto });
            return result > 0;
        }




        public async Task<bool> ModificarSocio(Socio socio)
        {
            var db = dbConnection();

            var sql = @"
                        UPDATE public.""Socios"" 
                        SET nombre = @nombre,       
                            apellido = @apellido,        
                            direccion = @direccion,   
                            telefono = @telefono,       
                            foto = @foto,  
                            dni = @dni 
                        WHERE  nrosocio = @nrosocio";
            var result = await db.ExecuteAsync(sql, new { socio.nombre, socio.apellido, socio.nrosocio, socio.direccion, socio.telefono, socio.foto, socio.dni });
            return result > 0;
        }
        public async Task<bool> BorrarSocio(Socio socio)
        {
            var db = dbConnection();

            var sql = @"
                        DELETE
                        FROM public.""Socios""  
                        WHERE  @nrosocio = nrosocio";

            var result = await db.ExecuteAsync(sql, new { nrosocio = socio.nrosocio });
            return result > 0;
        }


        public async Task<IEnumerable> VerCuota(int nrosocio)
        {
            var db = dbConnection();

            var sql = @"
                        SELECT id, monto, mes, nrosocio
                        FROM public.""Cuotas""
                        WHERE nrosocio = @nrosocio";

            return await db.QueryAsync<Cuota>(sql, new { nrosocio = nrosocio });

        }


        public async Task<bool> generarCuota(Cuota cuota)
        {
            var db = dbConnection();

            var sql = @"
                        INSERT INTO public.""Cuotas""(monto, mes, nrosocio, pago)
                    VALUES(@monto,@mes,@nrosocio, @pago)";


            var result = await db.ExecuteAsync(sql, new { cuota.monto, cuota.mes, cuota.nrosocio, cuota.pago });
            return result > 0;
        }
        public async Task<bool> Pagar(int id)
        {
            var db = dbConnection();

            var sql = @"
                        UPDATE public.""Cuotas"" 
                        SET pago = true 
                           
                        WHERE  id = @id";
            var result = await db.ExecuteAsync(sql, new { id = id });
            return result > 0;
        }
    }
}


            /* public async Task<IEnumerable> generarCuota()
                {
                    var db = dbConnection();


                    var sql = @"
                                SELECT nrosocio
                                FROM public.""Socios""";


                    var nsocio = await db.QueryAsync<Socio>(sql, new { });
                    foreach (IEnumerable nrosocio in nsocio )
                    {
                        if ( nrosocio == null)
                        {
                            return null;
                        }
                        else {
                        return nrosocio;
                        }

                    }*/
       
