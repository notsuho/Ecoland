using UnityEngine;

/*
Stores selected NewsItem.
Can be read and modified across scenes.
Currently saved by NewsListing and read by NewsDisplay.
*/
public static class SelectedNews
{
    public static NewsItem current;
}