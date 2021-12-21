using ClassLibrary1.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace ClassLibrary1.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly CLContext _context;

        public ClienteRepository(CLContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetClientes()
        {
            var clientes = await _context.Clientes.ToListAsync();
            return clientes;
        }

        public async Task<Cliente> GetClienteById(int id)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(x => x.NumCliente == id);
#pragma warning disable CS8603 // Possible null reference return.
            return cliente;
#pragma warning restore CS8603 // Possible null reference return.

        }

        public async Task InsertCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> UpdateCliente(Cliente cliente)
        {
            var currentCliente = await GetClienteById(cliente.NumCliente);

            currentCliente.Nombre = cliente.Nombre;
            currentCliente.Correo = cliente.Correo;
            currentCliente.Edad = cliente.Edad;
            currentCliente.Telefono = cliente.Telefono;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeleteCliente(int id)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(x => x.NumCliente == id);
#pragma warning disable CS8604 // Possible null reference argument.
            _context.Clientes.Remove(cliente);
#pragma warning restore CS8604 // Possible null reference argument.
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }




    }
}
