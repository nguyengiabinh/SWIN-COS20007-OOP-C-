from clock import Clock

class Counter:
    def __init__(self):
        self.clock = Clock()

    def run(self, duration):
        for _ in range(duration):
            self.clock.tick()
            print(self.clock)