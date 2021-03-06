using System;
using System.Collections.Generic;
using System.Data;

using Keepr.Models;
using Keepr.Repositories;


namespace Keepr.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _repo;
    public VaultsService(VaultsRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<Vault> Get(string userId)
    {
      return _repo.Get(userId);
    }

    public Vault Create(Vault newVault)
    {
      _repo.Create(newVault);
      return newVault;
    }
    internal Vault GetById(int id, string userId)
    {
      var exists = _repo.GetById(id);
      if (exists == null) { throw new Exception("Invalid Id"); }
      else if (exists.UserId != userId)
      {
        throw new Exception("You can't access that");
      }
      return exists;
    }

    // internal Vault Edit(Vault update)
    // {
    //   var exists = _repo.GetById(update.Id);
    //   if (exists == null) { throw new Exception("Invalid Id"); }
    //   _repo.Edit(update);
    //   return update;
    // }

    internal string Delete(int id, string userId)
    {
      var exists = _repo.GetById(id);
      if (exists == null) { throw new Exception("Invalid Id"); }
      else if (exists.UserId != userId)
      {
        throw new Exception("You can't do that");
      }
      _repo.Delete(id);
      return "Successfully deleted..";
    }
  }
}