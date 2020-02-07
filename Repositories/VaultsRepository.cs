using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
  public class VaultsRepository
  {
    private readonly IDbConnection _db;

    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }

    // internal IEnumerable<Vault> Get()
    // {
    //   string sql = "SELECT * FROM vaults WHERE isPrivate = 0;";
    //   return _db.Query<Vault>(sql);
    // }

    internal Vault Create(Vault VaultData)
    {
      string sql = @"INSERT INTO keeps (name, description) VALUES (@Name, @Description);
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, VaultData);
      VaultData.Id = id;
      return VaultData;
    }

    internal Vault GetById(int id)
    {
      string sql = "SELECT * FROM vaults WHERE id = @id";
      return _db.QueryFirstOrDefault<Vault>(sql, new { id });
    }
    // internal void Edit(Vault update)
    // {
    //   string sql = @"
    //         UPDATE vaults
    //         SET 
    //         name = @Name, description = @Description WHERE id = @Id;";
    //   _db.Execute(sql, update);
    // }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM vaults WHERE id = @id";
      _db.Execute(sql, new { id });
    }
  }
}