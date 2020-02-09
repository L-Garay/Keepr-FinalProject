using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;
    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal VaultKeep Find(VaultKeep newData)
    {
      string sql = "SELECT * FROM vaultkeeps WHERE (vaultId = @vaultId AND keepId = @keepId)";
      return _db.QueryFirstOrDefault(sql, newData);
    }

    internal IEnumerable<Keep> GetKeepsByVaultId(int id)
    {
      string sql = @"
      SELECT k.* FROM vaultkeeps vk JOIN keeps k ON k.id = vk.keepId WHERE vaultId = @id;";
      return _db.Query<Keep>(sql, new { id });
    }

    internal VaultKeep Create(VaultKeep newData)
    {
      string sql = @"
            INSERT INTO vaultkeeps 
            (keepId, vaultId, userId) 
            VALUES 
            (@keepId, @vaultId, @userId);
            SELECT LAST_INSERT_ID();
            ";
      int id = _db.ExecuteScalar<int>(sql, newData);
      newData.Id = id;
      return newData;
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM vaultkeeps WHERE id = @id;";
      _db.Execute(sql, new { id });


    }
  }
}