using Firebase.Database;

namespace APP_DOAN
{
    internal class DeleteCourse
    {
        private string courseId;
        private FirebaseClient client;

        public DeleteCourse(string courseId, FirebaseClient client)
        {
            this.courseId = courseId;
            this.client = client;
        }
    }
}