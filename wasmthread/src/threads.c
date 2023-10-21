#include <pthread.h>
#include <stdio.h>
#include <string.h>

#define NUM_THREADS 10

void *thread_entry_point(void *ctx) {
  int id = (int) ctx;
  printf(" in thread %d\n", id);
  return 0;
}

extern void launch_threads() {
  pthread_t threads[10];
  for (int i = 0; i < NUM_THREADS; i++) {
    int ret = pthread_create(&threads[i], NULL, &thread_entry_point, (void *) i);
    if (ret) {
      printf("failed to spawn thread: %s", strerror(ret));
    }
  }
  for (int i = 0; i < NUM_THREADS; i++) {
    pthread_join(threads[i], NULL);
  }
}

int main(int argc, char **argv) {
  launch_threads();
  return 0;
}