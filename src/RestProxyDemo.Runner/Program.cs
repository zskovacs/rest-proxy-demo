using RestProxyDemo;

const string BASEURL = "https://petstore.swagger.io";
var proxyFactory = new ProxyFactory(BASEURL);
var proxy = proxyFactory.Create();
var pet = await proxy.GetPetByIdAsync(1);

Console.WriteLine("END");