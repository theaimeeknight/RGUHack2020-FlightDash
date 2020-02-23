﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace FlightDashWeb
{
    public partial class MainPage : Page
    {
        public Game Game { get; set; } = new Game();

        public MainPage()
        {
            this.InitializeComponent();
            Game.InitializeGame();
            // Enter construction logic here...
            output.Text += Game.GetRoomHeader();
            statusScreen();
        }

        private void statusScreen()
        {
            directionList.Items.Clear();
            foreach (var currentRoomExit in Game.CurrentRoom.Exits)
            {
                directionList.Items.Add(currentRoomExit);
            }
        }
        private void direction_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void actionButton_Click(object sender, RoutedEventArgs e)
        {
            HandleInput();
        }

        private void input_KeyDown(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            if(e.Key==VirtualKey.Enter)
            {
                HandleInput();
            }
        }

        private void HandleInput()
        {
            pastInputList.Items.Add(input.Text);
            pastInputList.SelectedIndex = pastInputList.Items.Count - 1;
            var parsed = Game.TryParseInput(input.Text, out var outputText);
            if (parsed)
            {
                output.Text += "> " + input.Text + Environment.NewLine;
                output.Text += outputText;
                input.Text = "";
            }
            else
            {
                output.Text += "> " + input.Text + Environment.NewLine;
                output.Text += outputText;
            }

            statusScreen();
        }

        private void directionList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedExit = directionList.SelectedItem as Exit;
            if (selectedExit == null)
                return;
            input.Text = "go " + (selectedExit.ExitNames.Length > 0 ? selectedExit.ExitNames[0] : "");
        }
    }
}
