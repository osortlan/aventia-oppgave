
using Microsoft.AspNetCore.Mvc;

namespace backend.Auth;

public record GetTokenRequest(string username, string password);