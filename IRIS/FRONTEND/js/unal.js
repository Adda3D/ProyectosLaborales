
                var nav = false;

                function openNav() {
                    document
                        .getElementById("mySidebar")
                        .style
                        .right = "0px";
                    document
                        .getElementById("main")
                        .style
                        .right = "200px";
                    document
                        .getElementById("openbtnId")
                        .style
                        .backgroundPosition = "35px 0";    
                        nav = true;
                }

                /* Set the width of the sidebar to 0
		and the left margin of the page content to 0 */
        
                function closeNav() {
                    document
                        .getElementById("mySidebar")
                        .style
                        .right = "-200px";
                    document
                        .getElementById("main")
                        .style
                        .right = "0px";
                    document
                        .getElementById("openbtnId")
                        .style
                        .backgroundPosition = "0 0";                        
                        nav = false;
                }
                function toggleNav() {
      nav ? closeNav() : openNav();
    }
            