using System;
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

    internal object Create(VaultKeep newData)
    {
      VaultKeep exists = _vkr.Find(newData);
      if (exists != null) { throw new Exception("Student already enrolled"); }
      _vkr.Create(newData);
      return "Successfully Joined";
    }

    internal object Delete(VaultKeep vk)
    {
      VaultKeep exists = _vkr.Find(vk);
      if (exists == null) { throw new Exception("Invalid Id Combination"); }
      _vkr.Delete(exists.Id);
      return "Successfully Deleted";
    }
  }
}