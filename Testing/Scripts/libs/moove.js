
    var originalX = new Array();
    var originalY = new Array();
    var originalWidth = new Array();
    var originalHeight = new Array();

    var mousex = 0;
    var mousey = 0;

    $(".logoblock").each(function (e) {
        originalX[e] = $(this).css('left').replace("px", "");
        originalY[e] = $(this).css('top').replace("px", "");
        originalWidth[e] = $(this).css('width').replace("px", "");
        originalHeight[e] = $(this).css('height').replace("px", "");

    });

    $("body").mousemove(function (e) {
        moveblocks();
        mousex = e.pageX - ($("#logospace").offset().left);
        mousey = e.pageY - ($("#logospace").offset().top);
    });

    function resetblocks() {
        $(".logoblock").each(function (e) {
            $(this).css('left', originalX[e] + "px");
            $(this).css('top', originalY[e] + "px");
        });
    }

    function setpos(element, x, y) {
        x = Math.round(x, 0);
        y = Math.round(y, 0);
        try {
            $(element).css('left', x + "px");
            $(element).css('top', y + "px");
        }
        catch (err) {
            //do nothing
        }
    }

    function setscale(element, x, y) {
        x = Math.round(x, 0);
        y = Math.round(y, 0);
        try {
            $(element).css("width", x + "px");
            $(element).css("height", y + "px");
        }
        catch (err) {
            //do nothing
        }
    }

    function moveblocks() {
        $(".logoblock").each(function (e) {

            range = 30;

            try {
                leftstring = $(this).css('left');
                topstring = $(this).css('top');
            }
            catch (err) {
                //do nothing
            }

            if (leftstring && topstring) {
                var left = parseInt(leftstring.replace("px", ""));
                var top = parseInt(topstring.replace("px", ""));

                original_left = originalX[e];
                original_top = originalY[e];
                original_width = originalWidth[e];
                original_height = originalHeight[e];

                dx = left - mousex; //distance in x
                dy = top - mousey; //distance in y
                dist = Math.sqrt(dx * dx + dy * dy);

                if (dist < range) {
                    if (dist == 0) {

                    }
                    else {
                        dx = (range - dist) * dx / dist;
                        dy = (range - dist) * dy / dist;
                        newleft = (left + dx * 0.5);
                        newtop = (top + dy * 0.5);
                    }

                }
                else {
                    newleft = left - ((left - original_left) / 5);
                    newtop = top - ((top - original_top) / 5);

                    if (Math.abs(newleft - original_left) < 5) {
                        newleft = original_left;
                    }
                    if (Math.abs(newtop - original_top) < 5) {
                        newtop = original_top;
                    }
                }

                xscale = (100 + (newleft - original_left)) / 100;
                yscale = (100 + (newtop - original_top)) / 100;

                newwidth = Math.abs(original_width * yscale);
                newheight = Math.abs(original_height * xscale);

                if (newwidth < 2)
                    newwidth = 2;

                if (newheight < 2)
                    newheight = 2;

                setpos(this, newleft, newtop);
                setscale(this, newwidth, newheight);
            }

        });
    }
    //setInterval ( moveblocks, 1 );