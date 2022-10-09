Controls:
General
Q - Quit
R - Reset
T/Y - Swap block
U/I - Swap item
O/P - Swap enemy
WASD - Move
1/2/3 - Use item
Z/N - Attack w/ sword
E - Become damaged

Known bugs:
- Some of Link's sprites have pixels clipping in from other frames
- You can spam Link's items for right now, this will be fixed once he has a functional inventory/health system
- When moving in one direction, then pressing another movement key while still holding the original key, link will not change directions
  until the original key is released. This might not be that big of an issue but it could be more responsive. This is caused by the
  TryMove() function in Link2, because without that function, link's sprite will not animate when holding multiple WASD keys
  (he will still move, just not animate) because multiple commands are executing at once which makes him rapdily change states.
  Changing states builds a new sprite, and so the old sprite gets overwritten with a new one at frame 0 and it looks like he is not animating.