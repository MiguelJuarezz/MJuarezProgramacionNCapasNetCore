
ReadFile();
static void ReadFile()
{
    string file = @"C:\Users\digis\Documents\JOSE MIGUEL PEREZ JUAREZ\Usuarios.txt";
    if (File.Exists(file))
    {
        StreamReader TextFile = new StreamReader(file);
        string line;
        line = TextFile.ReadLine();
        while ((line = TextFile.ReadLine()) != null)
        {
            string[] lines = line.Split('|');

            ML.Usuario usuario = new ML.Usuario();

            usuario.Nombre = lines[0];
            usuario.ApellidoPaterno = lines[1];
            usuario.ApellidoMaterno = lines[2];
            usuario.FechaNacimiento = lines[3];
            usuario.Sexo = lines[4];
            usuario.Telefono = lines[5];
            usuario.Email = lines[6];
            usuario.UserName = lines[7];
            usuario.Password = lines[8];
            usuario.Celular = lines[9];
            usuario.Curp = lines[10];
            usuario.Imagen = null;

            usuario.Rol = new ML.Rol();
            usuario.Rol.IdRol = int.Parse(lines[11]);

            usuario.Direccion = new ML.Direccion();
            usuario.Direccion.Calle = lines[12];
            usuario.Direccion.NumeroInterior = lines[13];
            usuario.Direccion.NumeroExterior = lines[14];

            usuario.Direccion.Colonia = new ML.Colonia();
            usuario.Direccion.Colonia.IdColonia = int.Parse(lines[15]);

            ML.Result result = BL.Usuario.Add(usuario);

            if (result.Correct)
            {
                Console.WriteLine("Correcto");
                Console.ReadKey();
            }
            else
            {
                StreamWriter sw = new StreamWriter("C:\\Users\\digis\\Documents\\JOSE MIGUEL PEREZ JUAREZ\\Error.txt");
                sw.WriteLine("Existe Un Error " + result.ErrorMessage);
                sw.Close();
            }

        }
    }
}