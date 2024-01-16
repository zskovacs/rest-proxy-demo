using Microsoft.Extensions.Logging;
using RestProxyDemo;

using ILoggerFactory factory = LoggerFactory.Create(builder => builder.SetMinimumLevel(LogLevel.Debug).AddConsole());
ILogger logger = factory.CreateLogger("Program");

const string BASEURL = "https://petstore.swagger.io/v2";
const string BEARERTOKEN = "";
var proxyFactory = new PetProxyFactory(BASEURL, BEARERTOKEN, logger);
var proxy = proxyFactory.Create();
var pet = await proxy.GetPetByIdAsync(1);

Console.WriteLine("END");