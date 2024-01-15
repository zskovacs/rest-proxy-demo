using RestProxyDemo;

const string BASEURL = "https://petstore.swagger.io/v2";
const string BEARERTOKEN = "";
var proxyFactory = new PetProxyFactory(BASEURL, BEARERTOKEN);
var proxy = proxyFactory.Create();
var pet = await proxy.GetPetByIdAsync(1);

Console.WriteLine("END");