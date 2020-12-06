# Toilet

A simple simulation of the producer-consumer problem using threading in .NET on the example of people queueing in front of multiple toilets.

It is being implemented using a basic `FIFOQueue` and a more sophisticated `ToiletQueue` where elements with the shortest due date will be processed next.
