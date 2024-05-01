# Solucion de Vulnerabilidades

## Solucion de la Vulnerabilidad CSRF

> Views
```C#
    <form action="@Url.Action("Index","Acceso")" method="post">
        @Html.AntiForgeryToken()

    </form>
```

> Controller

```C#
    [HttpPost]
    [ValidateAntiForgeryToken]
    public JsonResult OperacionCarrito(int idproducto,bool sumar)
    {
        return Json(new { respuesta = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

    }
```

## Solucion de la Vulnerabilidad CSP

```C#

	<system.webServer>

		<httpProtocol>
			<customHeaders>
				<add name="X-Frame-Options" value="DENY" />
				<add name="Content-Security-Policy" value="script-src 'self' 'unsafe-inline' https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js;        style-src 'self' 'unsafe-inline' https://fonts.googleapis.com ;       font-src 'self' 'unsafe-inline' https://fonts.gstatic.com;" />

			</customHeaders>
		</httpProtocol>
		
		
	</system.webServer>

```

## Solucion de la Vulnerabilidad  en la Libreria Jquery

```C#
Actualizacion de la libreria usando los paquetes NuGet
```