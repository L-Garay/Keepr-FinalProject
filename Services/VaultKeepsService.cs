using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _vkr;
    public VaultKeepsService(VaultKeepsRepository vkr)
    {
      _vkr = vkr;
    }

    internal IEnumerable<Keep> GetKeepsByVaultId(int id)
    {
      return _vkr.GetKeepsByVaultId(id);
    }
    internal VaultKeep Create(VaultKeep newData)
    {
      // VaultKeep exists = _vkr.Find(newData);
      // if (exists != null) { throw new Exception("Already a combination"); }
      _vkr.Create(newData);
      return newData;
    }

    internal string Delete(int vaultId, int keepId, string userId)
    {
      VaultKeep exists = _vkr.Find(vaultId, keepId);
      if (exists == null) { throw new Exception("Can't find it"); }
      else if (exists.UserId != userId)
      {
        throw new Exception("You can't do that");
      }
      _vkr.Delete(exists.Id);
      return "Successfully deleted";
    }

  }
}