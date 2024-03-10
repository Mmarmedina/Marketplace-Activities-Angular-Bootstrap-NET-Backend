using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts.DTOs;



namespace SPRENCIA.Application.Mappers
{
    public class ActivityMapper
    {
        // MMM Crear un objeto ActivityDto que contenga información de la actividad, los horarios y las opiniones para enviar al frontend (suma DTO ActivityDto, ScheduleDto, ReviewDto).
        public static ActivityDto MapToResponseActivityDto(ActivityDto activityDto, List<ScheduleDto> schedules, List<ReviewDto> reviews)
        {
            ActivityDto responseActivityDto = new ActivityDto();
            responseActivityDto.Id = activityDto.Id;
            responseActivityDto.Title = activityDto.Title;
            responseActivityDto.Description = activityDto.Description;
            responseActivityDto.Price = activityDto.Price;
            responseActivityDto.Schedule = schedules;
            responseActivityDto.Review = reviews;

            return responseActivityDto;
        }

        // MMM Crear UNA LISTA DE OBJETOS del tipo ActivityDto que contenga información de la actividad, los horarios y las opiniones para enviar al frontend (suma DTO ActivityDto, ActivitiesSchedulesSchedule, ReviewDto).
        public static List<ActivityDto> MapToResponseActivitiesDto(List<ActivityDto> activitiesDto, List<ActivitiesSchedulesSchedules> activitiesShedulesDto)
        {
            // MMM Borrar comentarios. 
                // Me he traido del repositorio una lista que tiene el ID de actividad + ID horario + la tabla schedule (ID del horario + el Name).
                // Yo necesito devolver al front únicamente un scheduleDto que incluye el ID y el horario (name) de la actividad.
                // Necesito que la lista que recibo con ambas tablas, me convierta en otra lista con un objeto del tipo ScheduleDto (solo el ID de la actividad con su horario). 
                // Problema que he tenido cómo creo ese objeto teniendo la lista de ActivitiesSchedulesSchedules (forma más simple que la mía)?
                // Entonces cuando lo tenga en cada vuelta del foreach el objeto Schedule, equiparo: activityResponseDto.Schedule = al objeto creado;

            // MMM Se inciacializa una nueva lista de ActivityDto que almacenará las actividades con sus horarios y opiniones.
            List<ActivityDto> activitiesResponseDto = new List<ActivityDto>();

            // MMM Se itera sobre la lista de actividades pasadas por parámetro en la variable activitiesDto.
            foreach (ActivityDto activityDto in activitiesDto)
            {
                // MMM Se crea un nuevo objeto ActivityDto para almacenar las actividades con los horarios.
                ActivityDto activityResponseDto = new ActivityDto();

                // MMM Se copian las propiedades y valores de activityDto pasado por parámetro al objeto que va almacenar la respuesta para el frontend: activityResponseDto.
                activityResponseDto.Id = activityDto.Id;
                activityResponseDto.Title = activityDto.Title;
                activityResponseDto.Description = activityDto.Description;
                activityResponseDto.Price = activityDto.Price;

                // MMM Lógica para asignar los horarios a cada actividad.

                // Mapear convertir lista de objetos tipo Activities_Schedules + Schedules en SchedulesDto.
                List<ScheduleDto> schedulesForActivity = ScheduleMapper.MapToSchedulesDtoFromJoinActivitiesSchedulesSchedules(activityDto, activitiesShedulesDto);

                /*  Se crea un objeto del tipo ScheduleDto (que tendrá el ID del horario y el horario).
                List<ScheduleDto> schedulesForActivity = new List<ScheduleDto>();

                // Se ha recibido por parémetro una lista que es la suma de ActivitiesSchedules + Schedules, almacenada en activitiesShedulesDto. 
                // Se usa un bucle anidado para iterar dentro de la tabla ActivitiesSchedules que está dentro de activitiesShedulesDto. 
                foreach (ActivitiesSchedulesSchedules activitySchedulesDtoItem in activitiesShedulesDto)
                {
                    foreach (ActivitiesSchedules activitySchedule in activitySchedulesDtoItem.ActivitiesSchedules)
                    {
                        // Si el ID de la actividad (contenido en activityDto) conincide con el ID de la actividad de la tabla intermedia (activities_schedules), se crea un objeto ScheduleDto, con el ID del horario y su el Name de éste. 
                        if (activitySchedule.ActivityId == activityDto.Id)
                        {
                            ScheduleDto scheduleDto = new ScheduleDto
                            {
                                Id = activitySchedule.ScheduleId,
                                Name = activitySchedule.Schedule.Name
                            };
                            // Cada objeto creado en cada vuelta se añade a schedulesForActivities.
                            schedulesForActivity.Add(scheduleDto);
                        }
                    }
                }
                */

                // Se asigna la lista de horarios filtrados (schedulesForActivity) a la propiedad Schedule de la actividad actual 
                activityResponseDto.Schedule = schedulesForActivity;

                // Asignar las opiniones a ActivityDto
                // activityResponseDto.Review = reviewDto;


                activitiesResponseDto.Add(activityResponseDto);
            }

            return activitiesResponseDto;

        }

        // MMM Convertir LISTA de objetos tipo Actividad a lista de objetos tipo ActivityDto (solo información de la actividad, sin horarios ni opiniones).
        public static List<ActivityDto> MapToActivitiesDto(List<Activity> activities)
        {
            List<ActivityDto> activitiesDto = new List<ActivityDto>();

            foreach (Activity activity in activities)
            {
                // Se crea un objeto ActivityDto a partir del objeto Activity actual
                ActivityDto activityDto = ActivityMapper.MapToActivityDto(activity);
                activitiesDto.Add(activityDto);
            }

            return activitiesDto;

        }

        // MMM Convertir UN OBJETO tipo Actividad a objeto tipo ActivityDto (solo información de la actividad, sin horarios ni opiniones).
        public static ActivityDto MapToActivityDto(Activity activity)
        {
            ActivityDto activityDto = new ActivityDto();
            activityDto.Id = activity.Id;
            activityDto.Title = activity.Title;
            activityDto.Description = activity.Description;
            activityDto.Price = activity.Price;

            return activityDto;
        }



        /* OTRA VERSION: ESTA FUNCIONA SIN ERRORES PERO SACA TODAS LOS HORARIOS NO EL DE LA ACTIVIDAD EN PARTICULAR.
        // MMM Crear UNA LISTA DE OBJETOS del tipo ActivityDto que contenga información de la actividad, los horarios y las opiniones para enviar al frontend (suma DTO ActivityDto, ScheduleDto, ReviewDto).
        public static List<ActivityDto> MapToResponseActivitiesDto(List<ActivityDto> activitiesDto, List<ActivitiesSchedulesSchedules> activitiesShedulesDto, List<ReviewDto> reviewDto)
        {
            // Me he traido del repositorio una lista que tiene el ID de actividad + ID horario + la tabla schedule (ID del horario + el Name).
            // Yo necesito devolver al front únicamente un scheduleDto que incluye el ID y el horario (name) de la actividad.
            // Cómo creo ese objeto teniendo la lista de ActivitiesSchedulesSchedules.
            // Entonces cuando lo tenga en cada vuelta del foreach el objeto, equiparo: activityResponseDto.Schedule = al objeto creado;
            // Necesito que la lista que recibo con ambas tablas, me convierta en otra lista con un objeto del tipo Schedule (solo el ID de la actividad con su horario). 
            // En cada vuelta del bucle foreach de Activity Dto necesito igualara activityResponseDtoSchedule = ScheduleDto.
            // Como consigo 


            List<ScheduleDto> schedulesDto = new List<ScheduleDto>();

            foreach (ActivitiesSchedulesSchedules activityShedulesDto in activitiesShedulesDto)
            {
                foreach (ActivitiesSchedules activitySchedulesDtoItem in activityShedulesDto.ActivitiesSchedules)
                {
                    int id = activitySchedulesDtoItem.ScheduleId;
                    string name = activitySchedulesDtoItem.Schedule.Name;
                    // int activityId = activitySchedulesDtoItem.ActivityId;

                    ScheduleDto scheduleDto = new ScheduleDto
                    {
                        Id = id,
                        Name = name,
                        // ActivityId = activityId

                    };

                    schedulesDto.Add(scheduleDto);
                }

            }

            List<ActivityDto> activitiesResponseDto = new List<ActivityDto>();

            foreach (ActivityDto activityDto in activitiesDto)
            {
                ActivityDto activityResponseDto = new ActivityDto();

                activityResponseDto.Id = activityDto.Id;
                activityResponseDto.Title = activityDto.Title;
                activityResponseDto.Description = activityDto.Description;
                activityResponseDto.Price = activityDto.Price;
                
                List<ScheduleDto> activitySchdules = schedulesDto.Where(s => s.Id == activityDto.Id).ToList();
                activityResponseDto.Schedule = schedulesDto;

                activitiesResponseDto.Add(activityResponseDto);

            }

            
            
            return activitiesResponseDto;


            // Asignar las opiniones a ActivityDto
            // activityResponseDto.Review = reviewDto;


        }

        */




        /* una version
         * public static List<ActivityDto> MapToResponseActivitiesDto(List<ActivityDto> activitiesDto, List<ScheduleDto> schedulesDto, List<ReviewDto> reviewDto)
        {
            List<ActivityDto> activitiesResponseDto = new List<ActivityDto>();

            foreach (ActivityDto activityDto in activitiesDto)
            {
                ActivityDto activityResponseDto = new ActivityDto();

                activityResponseDto.Id = activityDto.Id;
                activityResponseDto.Title = activityDto.Title;
                activityResponseDto.Description = activityDto.Description;
                activityResponseDto.Price = activityDto.Price;

                // Asignar todos los horarios a ActivityDto.
                activityResponseDto.Schedule = schedulesDto;

                // Asociar las opiniones a la actividad.
                // List<ReviewDto>? reviewsDto = reviewDto.Where(r => r.ActivityId == activityDto.Id).ToList();

                // Asignar las opiniones a ActivityDto
                // activityResponseDto.Review = reviewDto;

                // Agregar la actividad a la lista de actividades con los horarios (almacenada en activitiesResponseDto)
                activitiesResponseDto.Add(activityResponseDto);
            }

            return activitiesResponseDto;

        }

        */

    }
}
