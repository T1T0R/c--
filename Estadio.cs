namespace ProyectoEstadio
{

    public class Estadio
    {
        public double metroscuadrados;
        public double porcentajeescenario;


        public Estadio() //CONSTRUCTOR ESTADIO
        {
            Console.WriteLine("Ingrese los metros cuadrados (m2) con los que cuenta el estadio");
            metroscuadrados = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el porcentaje (%) ocupado por el escenario");
            porcentajeescenario = Convert.ToDouble(Console.ReadLine());

        }


        protected double CalcularEspaciodisponible()  // METODO CALCULAR ESPACIO  
        {
            double espacioTotal = metroscuadrados * 4;

            double espacioEscenario = (porcentajeescenario / 100) * espacioTotal;

            double espacioTribunas = espacioTotal * 0.20;

            double espacioDisponible = espacioTotal - espacioTribunas - espacioEscenario;

            return espacioDisponible + espacioTribunas;
        }


        public int CalcularCapacidad() // METODO CAPACIDAD  
        {
            double  espacioDisponible=CalcularEspaciodisponible();
            return (int)Math.Round(espacioDisponible);  //REDONDEA ABAJO
        }


        public class Personas : Estadio //HERENCIA DE ESTADIO
        {
            public int PersonasenTribunas;

            public Personas() : base()
            {
                Console.WriteLine("Ingrese la cantidad de personas que caben en las tribunas");
                PersonasenTribunas = Convert.ToInt32(Console.ReadLine());
            }

        }

        public class Entradas : Personas //HERENCIA  DE PERSONAS
        {
            public double EntradaVIP;
            public double EntradaPOPULAR;


            public Entradas() : base()
            {
                Console.WriteLine("Ingrese el precio de las entrada V.I.P");
                EntradaVIP = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Ingrese el precio de las entrada popular (comun)");
                EntradaPOPULAR = Convert.ToDouble(Console.ReadLine());

                Console.Clear();
            }

            public double CalcularIngreso() //METODO DE ENTRADAS
            {
                int capacidad = CalcularCapacidad();

                int entradasVIP = (int)Math.Ceiling(capacidad * 0.30); //REDONDEA ARRIBA

                int entradasComunes = capacidad - entradasVIP;

                double ingresoTotal = (entradasVIP * EntradaVIP) + (entradasComunes * EntradaPOPULAR);

                return ingresoTotal;
            }

       
        }
    }

    class Program
    {
        static void Main () //MUESTRO EN PANTALLA  LOS RESULTADOS
        {
            
            Entradas entradas = new Entradas(); //INSTANCIA MATRIZ

            int capacidadpersonas = entradas.CalcularCapacidad();
            double ingresoTotal = entradas.CalcularIngreso();

            Console.WriteLine($"\nCantidad de entradas a vender: {capacidadpersonas}");
            Console.WriteLine($"Ingreso total por venta de entradas: ${ingresoTotal}");

            Console.ReadKey();
        }

    }
    
}

      
